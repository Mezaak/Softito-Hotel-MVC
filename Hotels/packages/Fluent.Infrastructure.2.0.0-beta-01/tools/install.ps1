param($installPath, $toolsPath, $package, $project)

$from = $null

$tempDir = $env:TEMP
$log = [System.IO.Path]::Combine($tempDir,"Fluent.Infrastructure\install.log")

if ([System.IO.File]::Exists($log))
{
    $lines = Get-Content $log | where {$_.Contains($project.FileName)} | where {$_.Contains($package.Id)}

    if ($lines -ne $null){
		    
		if ($lines.GetType().Name -eq 'String'){
			$lastline = $lines
		} else {
			$lastLine = $lines[$lines.Length-1]
		}
		       
        $props = $lastLine.Split(',')
        
        $versionRemoved = $props[1]
        $timeRemoved = $props[2]
        $timeRemoved = Get-Date -Date $timeRemoved
        $now = Get-Date
        
        $delta = New-TimeSpan $timeRemoved $now
        
        if ($delta.Minutes -lt 5){
            $from = $versionRemoved
        }
    }
}

if ($from -ne $null -and $from -ne $package.Version){
    $DTE.ItemOperations.Navigate("http://dn32.com.br/fluent/Install/AddReturn?eOperation=2&package=" + $package.Id + "&Version=" + $package.Version + "&PreviousVersion=" + $from)
}
else{
	$DTE.ItemOperations.Navigate("http://dn32.com.br/fluent/Install/AddReturn?eOperation=1&package=" + $package.Id + "&Version=" + $package.Version)
}