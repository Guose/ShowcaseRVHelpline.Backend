using System.Reflection;

namespace Helpline.WebAPI.Controller
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
