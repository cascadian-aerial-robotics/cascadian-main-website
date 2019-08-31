param (
    [string]$CodeLocation = $null, 
    [string]$OutPutFolder = $null,
    [string]$Configuration = $null
)

if( -not $CodeLocation) {  
    $CodeLocation = $Build.Repository.LocalPath
}

if( -not $OutPutFolder) {  
   $OutPutFolder = $Build.ArtifactStagingDirectory
}

if( -not $Configuration) {  
    $Configuration = 'Release'
}


dotnet build "$CodeLocation\solution files\mainwebsite-withtests.sln" --configuration $Configuration  --output  $OutPutFolder
