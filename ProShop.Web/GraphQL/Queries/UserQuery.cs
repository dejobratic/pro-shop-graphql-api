﻿using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using ProShop.Core.Services;
using ProShop.Web.GraphQL.Types;
using System;

namespace ProShop.Web.GraphQL.Queries
{
    public partial class RootQuery
    {
        private void InitializeUserQuery()
        {
            var userRepo = _provider
                .GetRequiredService<IUserRepository>();

            FieldAsync<UserType>(
                name: "user",
                resolve: async context =>
                {
                    var id = (Guid)context.Arguments["id"];
                    return await userRepo.Get(id);
                });

            FieldAsync<ListGraphType<UserType>>(
                name: "users",
                resolve: async context =>
                {
                    return await userRepo.GetAll();
                });
        }
    }
}