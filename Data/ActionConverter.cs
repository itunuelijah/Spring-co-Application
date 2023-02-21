using System.Text.Json.Serialization;
using System.Text.Json;

namespace SpringCoApplication.Data
{
    public class ActionConverter : JsonConverter<Action>
    {
        public override Action Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options)
        {
            // Do nothing, since System.Action instances cannot be serialized.
        }
    }

}
