# kubernetes.dotnetcore
kubernetes.dotnetcore

dotnet new mvc --name  kubernetes.dotnet.presentation

dotnet new webapi --name  kubernetes.dotnet.api

dotnet new classlib --name  kubernetes.dotnet.infrastructure

dotnet new classlib --name  kubernetes.dotnet.domain

dotnet sln add kubernetes-dotnetcore.sln src/kubernetes.dotnet.api/kubernetes.dotnet.api.csproj

dotnet sln add kubernetes-dotnetcore.sln src/kubernetes.dotnet.presentation/kubernetes.dotnet.presentation.csproj

dotnet sln add kubernetes-dotnetcore.sln src/kubernetes.dotnet.domain/kubernetes.dotnet.domain.csproj

dotnet sln add kubernetes-dotnetcore.sln src/kubernetes.dotnet.infrastructure/kubernetes.dotnet.infrastructure.csproj

dotnet add ../src/kubernetes.dotnet.api/kubernetes.dotnet.api.csproj reference ../src/kubernetes.dotnet.infrastructure/kubernetes.dotnet.infrastructure.csproj

dotnet add ../src/kubernetes.dotnet.api/kubernetes.dotnet.api.csproj reference ../src/kubernetes.dotnet.domain/kubernetes.dotnet.domain.csproj

dotnet add ../src/kubernetes.dotnet.presentation/kubernetes.dotnet.presentation.csproj reference ../src/kubernetes.dotnet.domain/kubernetes.dotnet.domain.csproj

