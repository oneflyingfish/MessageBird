@echo off
netsh advfirewall firewall delete rule name=126email dir=out program=all
exit
