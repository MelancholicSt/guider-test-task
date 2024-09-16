# Тестовое задание для С# разработчика
## Симонов Артём

Выполнена проектировка БД, в соответствии с ТЗ.
Отношение Заведений <-> Тэгов - Многие ко многим
Отношение Заведений <- Категорий - Многие к одному 

Но и были добавлены индексы:
### Заведения:
- добавлен индекс на адрес
### Категории:
- добавлен индекс на имя
В проекте использована многослойная архитектура раздёленная на: service layer, repository layer, controller layer. 

Стэк:
ASP.NET Core 8, MySQL 8, .Net Core 8

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
