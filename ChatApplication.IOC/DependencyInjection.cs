using ChatApplication.Application.Features.Commands.Mensage;
using ChatApplication.Application.Features.Commands.Users;
using ChatApplication.Application.Interfaces;
using ChatApplication.Application.Service;
using ChatApplication.Application.Settings;
using ChatApplication.Application.Validations.Mensage;
using ChatApplication.Application.Validations.User;
using ChatApplication.Dommain.Interfaces.Chat;
using ChatApplication.Dommain.Interfaces.Mensage;
using ChatApplication.Dommain.Interfaces.MensageStatus;
using ChatApplication.Dommain.Interfaces.User;
using ChatApplication.Dommain.Interfaces.UserFriend;
using ChatApplication.Infra.Context;
using ChatApplication.Infra.Repository.Chat;
using ChatApplication.Infra.Repository.Mensage;
using ChatApplication.Infra.Repository.MensageStatus;
using ChatApplication.Infra.Repository.User;
using ChatApplication.Infra.Repository.UserFriend;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace ChatApplication.IOC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        // Lê a seção BDSettings do appsettings.json
        var bdSettings = new BDSettings();
        configuration.GetSection("BDSettings").Bind(bdSettings);

        string connectionString =
            $"Host={bdSettings.Host};" +
            $"Port={bdSettings.Port};" +
            $"Database={bdSettings.Database};" +
            $"Username={bdSettings.Username};" +
            $"Password={bdSettings.Password};";

        services.AddDbContext<ContextDB>(options =>
        {
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.MigrationsAssembly(typeof(ContextDB).Assembly.FullName);
            });
        });

        // Registra o BDSettings no DI (caso precise em outras classes)
        services.Configure<BDSettings>(configuration.GetSection("BDSettings"));

        return services;
    }

    public static IServiceCollection AddInterfacesValidators(this IServiceCollection services)
    {

        services.AddScoped<IValidator<CriarUsuario>, CriarUsuarioValidate>();

        services.AddScoped<IValidator<SendMensage>, EnviarMensagemValidate>();

        return services;
    }

    public static IServiceCollection AddInterfaces(this IServiceCollection services)
    {
        // Mapeando repositorios dos Usuarios
        services.AddScoped<IUserRepositoryCommands, UserRepositoryCommands>();
        services.AddScoped<IUserRepositoryQuery, UserRepositoryQuery>();

        // Mapeando Repositorios dos Chats
        services.AddScoped<IChatRepositoryCommands, ChatRepositoryCommands>();
        services.AddScoped<IChatRepositoryQuery, ChatRepositoryQuery>();

        // Mapeando Repositorios das Mensagens
        services.AddScoped<IMensageRepositoryCommands, MensageRepositoryCommands>();
        services.AddScoped<IMensageRepositoryQuery, MensageRepositoryQuery>();

        // Mapeando Repositorios das MensageStatus
        services.AddScoped<IMensageStatusRepositoryCommands, MensageStatusRepositoryCommands>();
        services.AddScoped<IMensageStatusRepositoryQuery, MensageStatusRepositoryQuery>();

        //Mapeando Repositorios do UserFriends
        services.AddScoped<IUserFriendRepositoryCommands, UserFriendsRepositoryCommands>();
        services.AddScoped<IUserFriendRepositoryQuery, UserFriendsRepositoryQuery>();


        return services;
    }

    public static IServiceCollection AddInterfacesServices(this IServiceCollection services)
    {
        services.AddScoped<ISavedImages, SavedImage>();
        services.AddScoped<IUserValidations, UserValidations>();
        services.AddScoped<IValidateBase64, ValidateBase64>();

        return services;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(ctg => ctg.RegisterServicesFromAssembly(Assembly.Load("ChatApplication.Application")));

        return services;
    }

    public static IServiceCollection AddFluentValidate(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.Load("ChatApplication.Application"));

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AuthProj",
                Version = "v1"
            });

            var securitySchema = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Entre com o JWT Bearer",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securitySchema, new string[] {} }
    });
        });
        return services;
    }

    public static IServiceCollection Authentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSection = configuration.GetSection("Jwt");
        var jwtSettings = jwtSection.Get<JWTSettings>();

        services.Configure<JWTSettings>(jwtSection); // Disponibiliza o IOptions<JWTSettings> para injeção

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,

                ValidateAudience = true,
                ValidAudiences = jwtSettings.Audience, // <- aceita múltiplas audiências

                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                ValidateIssuerSigningKey = true,

                RoleClaimType = "Role" // usa o claim "Role" no token
            };
        });

        return services;
    }
}
