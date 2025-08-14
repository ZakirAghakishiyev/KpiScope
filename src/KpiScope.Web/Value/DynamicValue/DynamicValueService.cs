using System.ComponentModel;
using System.Text.Json;
using Ardalis.SharedKernel;
using AM=AutoMapper;
using KpiScope.Web.Value.DynamicValue.Update;
using KpiAgg =KpiScope.Core.KpiAggregate;
using KpiScope.Web.Value.DynamicValue.Create;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace KpiScope.Web.Value.DynamicValue;

public class DynamicValueService(IRepository<KpiAgg.DynamicValue> _repository, AM.IMapper _mapper) : IDynamicValueService
{
    public async Task<dynamic> GetDynamicValueAsync(int id)
    {
        var dynamicValue = await _repository.GetByIdAsync(id);
        if (dynamicValue == null)
        {
            throw new KeyNotFoundException($"DynamicValue with ID {id} not found.");
        }

        var value = JsonSerializer.Deserialize<dynamic>(dynamicValue.JsonValue);

        return value ?? throw new InvalidOperationException("Failed to deserialize DynamicValue JSON.");
    }

    public async Task<CreateDynamicValueResponse> CreateDynamicValueAsync(CreateDynamicValueRequest dynamicValue)
    {
        if (dynamicValue == null)
            throw new ArgumentNullException(nameof(dynamicValue), "DynamicValue cannot be null.");
        var value = SerializeDynamicValue(dynamicValue);
        var newDynamicValue = new KpiAgg.DynamicValue
        {
            Name = dynamicValue.Name,
            JsonValue = value
        };
        foreach(var item in dynamicValue.Layers)
        {
            newDynamicValue.Types.Add(item.Type);
        }
        var createdDynamicValue = await _repository.AddAsync(newDynamicValue);
        if (createdDynamicValue == null)
        {
            throw new InvalidOperationException("Failed to create DynamicValue.");
        }
        return _mapper.Map<CreateDynamicValueResponse>(createdDynamicValue);
    }

    public async Task<KpiAgg.DynamicValue> DeleteDynamicValueAsync(int id)
    {
        var dynamicValue = await _repository.GetByIdAsync(id);
        if (dynamicValue == null)
        {
            throw new KeyNotFoundException($"DynamicValue with ID {id} not found.");
        }

        await _repository.DeleteAsync(dynamicValue);
        return dynamicValue;
    }

    public async Task<UpdateDynamicValueResponse> UpdateDynamicValueAsync(int id,UpdateDynamicValueRequest dynamicValue)
    {
        if (dynamicValue == null)
            throw new ArgumentNullException(nameof(dynamicValue), "DynamicValue cannot be null.");

        var updatedJsonValue = SerializeDynamicValue(dynamicValue);
        var existingDynamicValue = await _repository.GetByIdAsync(id);
        if (existingDynamicValue == null)
        {
            throw new KeyNotFoundException($"DynamicValue with ID {id} not found.");
        }


        existingDynamicValue.JsonValue = updatedJsonValue;
        existingDynamicValue.Name = dynamicValue.Name;

        var updatedDynamicValue = await _repository.UpdateAsync(existingDynamicValue);
        if (updatedDynamicValue < 1)
        {
            throw new InvalidOperationException("Failed to update DynamicValue.");
        }
        return _mapper.Map<UpdateDynamicValueResponse>(existingDynamicValue);
    }

    public async Task<IEnumerable<KpiAgg.DynamicValue>> ListDynamicValueAsync()
    {
        var values = await _repository.ListAsync();
        return values ?? throw new InvalidOperationException("Failed to retrieve DynamicValues.");
    }
    
    private string SerializeDynamicValue<T>(T request) where T : Request
    {
        object? nested = null;

        for (int i = request.Layers.Count - 1; i >= 0; i--)
        {
            var layer = request.Layers[i];
            nested = nested == null
                ? layer.Value
                : new { Value = layer.Value, Next = nested };
        }

        return JsonSerializer.Serialize(nested, new JsonSerializerOptions { WriteIndented = true });
    }

}
