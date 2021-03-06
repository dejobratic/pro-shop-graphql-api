﻿using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using ProShop.Store.App.UseCases;
using ProShop.Store.Contract.Dtos;
using ProShop.Store.Contract.Requests;
using ProShop.Web.GraphQL.Types.Store;
using System;
using System.Collections.Generic;

namespace ProShop.Web.GraphQL.Queries
{
    public partial class RootQuery
    {
        private void InitializeProductQuery()
        {
            var commandFactory = _provider
                .GetRequiredService<IProductCommandFactory>();

            FieldAsync<ProductType>(
                name: "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve: async context =>
                {
                    var request = new GetProductByIdRequest { ProductId = context.GetArgument<Guid>("id") };
                    var command = commandFactory.Create<ProductDto>(request);

                    return await command.Execute();
                });

            FieldAsync<ListGraphType<ProductType>>(
                name: "products",
                resolve: async context =>
                {
                    var request = new GetAllProductsRequest();
                    var command = commandFactory.Create<IEnumerable<ProductDto>>(request);

                    return await command.Execute();
                });
        }
    }
}
