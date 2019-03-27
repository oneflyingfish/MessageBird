@echo off
netsh advfirewall firewall add rule name=126email dir=out program=all security=authnoencap action=allow
exit
