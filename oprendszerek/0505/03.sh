#!/bin/bash

read -p "Add meg a file nevét: " file

if [ ! -f $file ]; then
  echo "Nem létező file"
  exit 1
fi

if [ -w $file ]; then
  echo "A fájl írható."
else
  echo "A fájl nem írható"
fi

if [ -r $file ]; then
  echo "A fájl olvasható"
else
  echo "A fájl nem olvasható"
fi

if [ -x $file ]; then
  echo "A fájl futtatható"
else
  echo "A fájl nem futtatható"
fi
