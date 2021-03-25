$currentWi = [Security.Principal.WindowsIdentity]::GetCurrent()
$currentWp = [Security.Principal.WindowsPrincipal]$currentWi
if( -not $currentWp.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator))
{
    $boundPara = ($MyInvocation.BoundParameters.Keys | foreach{
        '-{0} {1}' -f  $_ ,$MyInvocation.BoundParameters[$_]} ) -join ' '
    $currentFile = (Resolve-Path  $MyInvocation.InvocationName).Path
    Start-Process "$psHome\powershell.exe" -ArgumentList "$currentFile" -Verb runas
    return
}

$TTS1 = "HKLM:\SOFTWARE\Microsoft\Speech_OneCore\Voices\Tokens\CortanaChinese"
$TTS1ATTRIB = "HKLM:\SOFTWARE\Microsoft\Speech_OneCore\Voices\Tokens\CortanaChinese\Attributes"
$TTS2 = "HKLM:\SOFTWARE\Microsoft\Speech\Voices\Tokens\CortanaChinese"
$TTS2ATTRIB = "HKLM:\SOFTWARE\Microsoft\Speech\Voices\Tokens\CortanaChinese\Attributes"
New-Item -Path $TTS1,$TTS2,$TTS1ATTRIB,$TTS2ATTRIB
New-ItemProperty -Path $TTS1,$TTS2 -Name "(default)" -PropertyType string -Value "Cortana - Chinese(Simplified)"
New-ItemProperty -Path $TTS1,$TTS2 -Name LangDataPath -PropertyType string -Value "%windir%\\Speech_OneCore\\Engines\\TTS\\zh-CN\\MSTTSLoczhCN.dat"
New-ItemProperty -Path $TTS1,$TTS2 -Name LangUpdateDataDirectory -PropertyType string -Value "%SystemDrive%\\Data\\SharedData\\Speech_OneCore\\Engines\\TTS\\zh-CN"
New-ItemProperty -Path $TTS1,$TTS2 -Name VoicePath -PropertyType string -Value "%windir%\\Speech_OneCore\\Engines\\TTS\\zh-CN\\M2052Hongyu"
New-ItemProperty -Path $TTS1,$TTS2 -Name VoiceUpdateDataDirectory -PropertyType string -Value "%SystemDrive%\\Data\\SharedData\\Speech_OneCore\\Engines\\TTS\\zh-CN"
New-ItemProperty -Path $TTS1,$TTS2 -Name 804 -PropertyType string -Value "Cortana - Chinese(Simplified)"
New-ItemProperty -Path $TTS1,$TTS2 -Name CLSID -PropertyType string -Value "{179F3D56-1B0B-42B2-A962-59B7EF59FE1B}"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Version -PropertyType string -Value "11.0"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Language -PropertyType string -Value "804"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Gender -PropertyType string -Value "Female"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Age -PropertyType string -Value "Adult"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name DataVersion -PropertyType string -Value "11.0.2013.1022"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name SharedPronunciation -PropertyType string -Value ""
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Name -PropertyType string -Value "Cortana - Chinese(Simplified)"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Vendor -PropertyType string -Value "Microsoft"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name PersonalAssistant -PropertyType string -Value "1"

$TTS1 = "HKLM:\SOFTWARE\Microsoft\Speech_OneCore\Voices\Tokens\CortanaEnglish"
$TTS1ATTRIB = "HKLM:\SOFTWARE\Microsoft\Speech_OneCore\Voices\Tokens\CortanaEnglish\Attributes"
$TTS2 = "HKLM:\SOFTWARE\Microsoft\Speech\Voices\Tokens\CortanaEnglish"
$TTS2ATTRIB = "HKLM:\SOFTWARE\Microsoft\Speech\Voices\Tokens\CortanaEnglish\Attributes"
New-Item -Path $TTS1,$TTS2,$TTS1ATTRIB,$TTS2ATTRIB
New-ItemProperty -Path $TTS1,$TTS2 -Name "(default)" -PropertyType string -Value "Cortana - English(United States)"
New-ItemProperty -Path $TTS1,$TTS2 -Name LangDataPath -PropertyType string -Value "%windir%\\Speech_OneCore\\Engines\\TTS\\en-US\\MSTTSLocenUS.dat"
New-ItemProperty -Path $TTS1,$TTS2 -Name LangUpdateDataDirectory -PropertyType string -Value "%SystemDrive%\\Data\\SharedData\\Speech_OneCore\\Engines\\TTS\\en-US"
New-ItemProperty -Path $TTS1,$TTS2 -Name VoicePath -PropertyType string -Value "%windir%\\Speech_OneCore\\Engines\\TTS\\en-US\\M1033Eva"
New-ItemProperty -Path $TTS1,$TTS2 -Name VoiceUpdateDataDirectory -PropertyType string -Value "%SystemDrive%\\Data\\SharedData\\Speech_OneCore\\Engines\\TTS\\en-US"
New-ItemProperty -Path $TTS1,$TTS2 -Name 409 -PropertyType string -Value "Cortana - English(United States)"
New-ItemProperty -Path $TTS1,$TTS2 -Name CLSID -PropertyType string -Value "{179F3D56-1B0B-42B2-A962-59B7EF59FE1B}"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Version -PropertyType string -Value "11.0"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Language -PropertyType string -Value "409"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Gender -PropertyType string -Value "Female"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Age -PropertyType string -Value "Adult"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name DataVersion -PropertyType string -Value "11.0.2013.1022"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name SharedPronunciation -PropertyType string -Value ""
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Name -PropertyType string -Value "Cortana - English(United States)"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name Vendor -PropertyType string -Value "Microsoft"
New-ItemProperty -Path $TTS1ATTRIB,$TTS2ATTRIB -Name PersonalAssistant -PropertyType string -Value "1"
