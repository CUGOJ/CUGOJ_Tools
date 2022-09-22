#! /bin/bash

dotnet pack -o ./nupkgs/ -p:PackageVersion=0.0.1

rm -rf ~/.nuget/packages/cugoj_tools/0.0.1/