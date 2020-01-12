using System;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Shared.IoC.Registries;
using Convey.CQRS.Queries;
using Newtonsoft.Json;

namespace Cinema.Shared.IoC.Dispatchers
{
    internal sealed  class QueryDispatcherAppRegistryDecorator : IQueryDispatcher
    {
        private readonly IQueryDispatcher _dispatcher;
        private readonly IAppTypesRegistry _registry;

        public QueryDispatcherAppRegistryDecorator(IQueryDispatcher dispatcher, IAppTypesRegistry registry)
        {
            _dispatcher = dispatcher;
            _registry = registry;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            var queryTypes = _registry.GetLocalTypes(query.GetType());

            if (!queryTypes.Any())
            {
                throw new InvalidOperationException("No query type found in requested module");
            }
            if (queryTypes.Count() > 1)
            {
                throw new InvalidOperationException("Query cannot be processed by more than one module");
            }

            var queryType = queryTypes.First();
            var json = JsonConvert.SerializeObject(query);
            var message = JsonConvert.DeserializeObject(json, queryType);

            var resultType = _registry.GetLocalTypes(typeof(TResult)).First();

            var task = (Task)_dispatcher.GetType()
                .GetMethods()
                .First(mi => mi.Name is nameof(_dispatcher.QueryAsync) && mi.GetGenericArguments().Length is 2)
                .MakeGenericMethod(queryType, resultType)
                .Invoke(_dispatcher, new object[] { message});

            await task;
            var result = (object) ((dynamic) task).Result;
            var resultJson = JsonConvert.SerializeObject(result);
            return JsonConvert.DeserializeObject<TResult>(resultJson);
        }

        public Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>
            => QueryAsync(query);
    }
}
