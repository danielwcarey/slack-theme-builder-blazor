# Blazor sample of slack-theme-builder
https://github.com/aharvard/slack-theme-builder

## Running the project
* Install the [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* From the shell:
   dotnet build
   dotnet run

* Navigate to either:
  http://localhost:5000
  https://localhost:5001

## Creating the project
dotnet new blazorserver

## Styling

/Pages/_Host.cshtml
[Handle errors in ASP.NET Core Blazor apps](https://docs.microsoft.com/en-us/aspnet/core/blazor/handle-errors?view=aspnetcore-3.1)


## Github issues

Two-way binding for input type Color isn't built-in yet. I worked around that by one-way binding the 
value and handling the onchange event that in turn, calls the callback method.
[Two way binding does not yet handle color picker...](https://github.com/dotnet/aspnetcore/issues/10376)



Blazor currently doesn't support css isloation;i.e. per component styles. It is being looked at!
[CSS Isolation in Blazor Components](https://github.com/dotnet/aspnetcore/issues/10170)





## References
[Create and use ASP.NET Core Razor components](https://docs.microsoft.com/en-us/aspnet/core/blazor/components?view=aspnetcore-3.1)
[ASP.NET Core Blazor state management]( https://docs.microsoft.com/en-us/aspnet/core/blazor/state-management?view=aspnetcore-3.1 )
[A Detailed Look at Data Binding in Blazor]( https://chrissainty.com/a-detailed-look-at-data-binding-in-blazor/ )