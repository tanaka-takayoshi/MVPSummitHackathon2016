cd $PSScriptRoot
dotnet restore
dotnet build
rm ./nupkgs/*
rm $env:USERPROFILE\".nuget\packages\dotnet-add"
cd ./dotnet-add
dotnet pack -o ../nupkgs
cd ../SampleTargets.PackerTarget
dotnet pack -o ../nupkgs
cd ..
cd ./sample/ConsumingProject
dotnet restore
dotnet add cs Test1
dotnet add cs Test/Test2
dotnet add if ITest




