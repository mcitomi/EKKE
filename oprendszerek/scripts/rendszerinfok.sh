#!/bin/bash

felhasznalo=$(whoami)

gepnev=$(hostname)

datumn=$(date)

konyvtar=$(pwd)

echo "- - - - - - - - - -"
echo "Rendszer informació"
echo "- - - - - - - - - -"

echo "Felhasználó: ${felhasznalo}"
echo "Gép neve: ${gepnev}"
echo "Aktuális konyvtar: ${konyvtar}"
echo "Dátum: ${datumn}"
echo "Script neve: $0"
