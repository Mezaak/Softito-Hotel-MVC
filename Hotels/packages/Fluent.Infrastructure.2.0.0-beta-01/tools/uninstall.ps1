param($installPath, $toolsPath, $package, $project)

$tempDir = $env:TEMP
$tempDir = [System.IO.Path]::Combine($tempDir,"Fluent.Infrastructure")
if (![System.IO.Directory]::Exists($tempDir)) {[System.IO.Directory]::CreateDirectory($tempDir)}
$file = [System.IO.Path]::Combine($tempDir, "install.log")
$datetime = Get-Date

$package.Id + "," + $package.Version + "," + $datetime.ToString() + "," + $project.FileName | out-file $file -append

$DTE.ItemOperations.Navigate("http://dn32.com.br/fluent/Install/AddReturn?eOperation=3&package=" + $package.Id + "&Version=" + $package.Version)