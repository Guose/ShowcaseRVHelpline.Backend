using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Helpline.WebAPI.Controller.Filters
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                schema.Enum.Clear();

                var names = Enum.GetNames(context.Type).ToList();

                names.ForEach(name => schema.Enum.Add(new OpenApiString($"{GetEnumIntegerValue(name, context)} = {name}")));

                // The missing piece that will make sure that the new schema will not replace the mock value with a wrong value
                // this is the default behvior - the first possible enum value as a default "example" value.
                schema.Example = new OpenApiInteger(GetEnumIntegerValue(names.First(), context));
            }
        }

        private int GetEnumIntegerValue(string name, SchemaFilterContext context) => Convert.ToInt32(Enum.Parse(context.Type, name));
    }
}
