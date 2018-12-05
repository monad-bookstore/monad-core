dotnet publish -c Release
cd "./bin/Release/netcoreapp2.1/publish"
rsync -v --stats --progress -a --force --exclude=appsettings.json -I . root@91.211.246.132:/.net/publish
cd "../../../"