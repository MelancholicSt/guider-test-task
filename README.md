# Тестовое задание для С# разработчика
## Симонов Артём

# О проекте

## БД
Выполнена проектировка БД, в соответствии с ТЗ.

Отношение Заведений <-> Тэгов - Многие ко многим

Отношение Заведений <- Категорий - Многие к одному 

Но и были добавлены индексы:
### Заведения:
- добавлен индекс на адрес
### Категории:
- добавлен индекс на имя

## Архитектура
В проекте использована многослойная архитектура раздёленная на: service layer, repository layer, controller layer. 

## Стэк:
- ASP.NET Core 8,
- MySQL 8,
- .NET Core 8

### Известные проблемы в проекте
В связи с добавлением асинхронности возникли трудности с выполнением операций на уровне DAL (Repository Layer + ContextLayer)

# Сборка и запуск
Сборка проиcходит с помощью запуска комманды в консоли проекта *dotnet build*. 
Для работоспособности потребуется скачать MySQL Server 8.0.39 и сделать миграцию с помощью EntityFramework(была идея дать возможность запуститься через докер контейнер, но времени не хватало):

## Зависимости:
```xml
 <ItemGroup>
        <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.8" />
        <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.8">
          <PrivateAssets>all</PrivateAssets>
          <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>
        <PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="8.0.8" />
        <PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="8.0.2" />
        <PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0"/>
    </ItemGroup>
```


