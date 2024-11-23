using System.Reflection;

namespace Helpline.Services.Abstractions
{
    public class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
