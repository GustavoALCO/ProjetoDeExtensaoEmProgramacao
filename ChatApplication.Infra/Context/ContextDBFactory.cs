﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using ChatApplication.Infra.Context;

namespace AuthUsers.infra.DbConfig;

public class ContextDBFactory : IDesignTimeDbContextFactory<ContextDB>
{
    public ContextDB CreateDbContext(string[] args)
    {

        var optionsBuilder = new DbContextOptionsBuilder<ContextDB>();

        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=chatdb;Username=chatuser;Password=Teste123");

        return new ContextDB(optionsBuilder.Options);
    }
}