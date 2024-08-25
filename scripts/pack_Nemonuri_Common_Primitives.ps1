$projPath = [System.IO.Path]::Combine($PSScriptRoot, "../src/Nemonuri.Common.Primitives/Nemonuri.Common.Primitives.csproj")
$env:DOTNET_CLI_UI_LANGUAGE = 'en'

dotnet pack $projPath