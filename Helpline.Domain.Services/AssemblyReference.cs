using System.Reflection;

namespace Helpline.Domain.Services
{
    public class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
