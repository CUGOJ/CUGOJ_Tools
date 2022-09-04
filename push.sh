#! /bin/bash
if [ -z "$NUGET_API_KEY" ]; then
    echo "NUGET_API_KEY is not set"
    exit 1
fi
for file in nupkgs/*
do
    if test -f $file
    then
        echo 'found package:' $file
        dotnet nuget push $file --api-key $NUGET_API_KEY --source https://api.nuget.org/v3/index.json
        break
    fi
done