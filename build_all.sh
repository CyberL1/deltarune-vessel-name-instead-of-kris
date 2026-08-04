#!/usr/bin/env bash

UMT_CLI_PATH=$1
XDELTA_CLI_PATH=$2
GAMES_PATH=$3

if test -z $UMT_CLI_PATH || test -z $XDELTA_CLI_PATH || test -z $GAMES_PATH; then
  echo "Usage: $0 path/to/UndertaleModToolCli path/to/xdelta path/to/games"
  exit 1
fi

echo "Preparing for build"

! test -d out && mkdir out || rm out/*

if test -f $GAMES_PATH/DELTARUNEdemo/data.win; then
  DATA_PATH=$GAMES_PATH/DELTARUNEdemo/data.win

  ./build_win.sh $UMT_CLI_PATH $DATA_PATH out/demo.win
  ./build_patch.sh $XDELTA_CLI_PATH $DATA_PATH out/demo.win out/demo.xdelta
else
  echo $GAMES_PATH/DELTARUNEdemo/data.win not found, skipping
fi

for chapter in 1 2 3 4 5; do
  DATA_PATH=$GAMES_PATH/DELTARUNE/chapter"$chapter"_windows/data.win

  if test -f $DATA_PATH; then
    ./build_win.sh $UMT_CLI_PATH $DATA_PATH out/chapter$chapter.win
    ./build_patch.sh $XDELTA_CLI_PATH $DATA_PATH out/chapter$chapter.win out/chapter$chapter.xdelta
  else
    echo $DATA_PATH not found, skipping
  fi
done
