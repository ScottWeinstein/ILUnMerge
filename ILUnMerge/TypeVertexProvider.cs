using QuickGraph.Providers;

namespace ACATool
{
    class TypeVertexProvider : TypedVertexProvider
    {
        public TypeVertexProvider() : base(typeof(TypeVertex)) { }
    }
}