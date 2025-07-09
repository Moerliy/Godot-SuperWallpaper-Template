#!/usr/bin/env bash
# hyprlock-wrapper.sh

# Hyprlock wrapper script that monitors screen lock/unlock events by parsing Hyprlock output.
# Maintains a state file containing "locked" or "unlocked" status in the user's cache directory.
# The state file enables external event providers to track the current lock state without
# directly interfacing with Hyprlock processes.

echo "[hyprlock-wrapper] Script started" >&2

# Where to write the lock state
STATE_FILE="$HOME/.cache/hyprlock_state"

# Ensure the state file exists
mkdir -p "$(dirname "$STATE_FILE")"
: > "$STATE_FILE"

# Initialize with locked state since Hyprlock starts locked
printf 'locked' > "$STATE_FILE"
echo "[hyprlock-wrapper] Initial state set to 'locked'" >&2

# Use stdbuf to disable buffering and process substitution for real-time processing
stdbuf -oL -eL hyprlock 2>&1 | while IFS= read -r line; do
  case "$line" in
    # This line indicates that user has logged in successfully 
    # and Hyprlock is now playing login animation
    *"[LOG] auth: authenticated for hyprlock"*)
      printf 'unlocked' > "$STATE_FILE"
      echo "[hyprlock-wrapper] Unlock event detected, wrote 'unlocked' to $STATE_FILE" >&2
      ;;
  esac
done

echo "[hyprlock-wrapper] hyprlock exited" >&2