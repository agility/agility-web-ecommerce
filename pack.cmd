del bin\*.* /s /q
del obj\*.* /s /q

nuget restore ..\Agility.Web.eCommerce.sln

rem create the component package
msbuild.exe ..\Agility.Web.eCommerce.sln /t:Build /p:Configuration=Release /m
nuget pack Agility.Web.eCommerce.nuspec

rem create the symbols package
msbuild.exe ..\Agility.Web.eCommerce.sln /t:Build /p:Configuration=Debug /m
nuget pack Agility.Web.eCommerce.symbols.nuspec -symbols