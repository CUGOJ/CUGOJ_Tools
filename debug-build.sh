#! /bin/bash

sh generate.sh

cd ./src

dotnet pack -o ../nupkgs/ -p:PackageVersion=0.0.1

cd ../

rm -rf ~/.nuget/packages/cugoj_tools/0.0.1/

cd ../CUGOJ_Core
pwd
sh update_nuget.sh

cd ../CUGOJ_Base
pwd
sh update_nuget.sh

cd ../CUGOJ_Tester
pwd
sh update_nuget.sh

cd ../CUGOJ_Gateway
pwd
sh update_nuget.sh

cd ../CUGOJ_Judger
pwd
sh update_nuget.sh

cd ../CUGOJ_Tools
pwd