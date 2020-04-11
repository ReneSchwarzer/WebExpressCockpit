#!/bin/bash
# Erstellt und verteilt den Cocpit-Service, ohne ihn zu starten.
# Das Starten und Stoppen erfolgt automatisch (Starten beim booten) 
# oder manuell über die Skripte start.sh und stop.sh.

export PATH=$PATH:/usr/share/dotnet-sdk/
export DOTNET_ROOT=/usr/share/dotnet-sdk/ 

dotnet build
dotnet publish

if (sudo systemctl -q is-enabled cocpit.service)
then
	sudo systemctl disable cocpit.service 
fi

sudo mkdir -p /opt/cocpit
sudo chmod +x /opt/cocpit


cp -Rf Cocpit.App/bin/Debug/netcoreapp3.1/publish/* /opt/cocpit
cp Cocpit.sh /opt/cocpit
sudo chmod +x /opt/cocpit/cocpit.sh

sudo cp cocpit.service /etc/systemd/system
sudo systemctl enable cocpit.service
