param (
    [string]$CodeLocation = $null, 
    [string]$OutPutFolder = $null,
    [string]$Configuration = $null
)

if( -not $CodeLocation) {  
    $CodeLocation = 'C:\code\cascadian-main-website\'
}

if( -not $OutPutFolder) {  
   $OutPutFolder =  'C:\temp\1'
}

if( -not $Configuration) {  
    $Configuration = 'Release'
}

Write-Host "Code Location: $CodeLocation"
Write-Host "Output folder: $OutPutFolder"
Write-Host "Configuration: $Configuration"

dotnet build "$CodeLocation\solution files\mainwebsite-withtests.sln" --configuration $Configuration  --output  $OutPutFolder
