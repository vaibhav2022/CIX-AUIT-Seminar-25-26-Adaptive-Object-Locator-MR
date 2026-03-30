# Adaptive Object Locator in Mixed Reality

## Overview
This project is a Mixed Reality adaptive object locator developed in Unity for Meta Quest 3.
It allows users to create, label, manage, and locate anchors in a passthrough environment using a Adaptive directional guidance arrow and controller-based interaction.

This project was developed for a seminar & demo on Adaptive UI in Mixed Reality using AUIT Toolkit.

---

## Main Demo Scene
`Assets/Scenes/AUIT_9_Final_Working.unity`

---

## Tested On
- Windows development machine
- Meta Quest 3
- Unity 6000.3.9f1

---

## Features
- Passthrough-based MR interaction on Meta Quest 3
- Manual anchor creation and deletion
- Fixed preset label assignment
- Saved anchor list with joystick navigation
- Directional arrow guidance to selected anchor
- Distance-based arrow scaling and opacity
- Near-target arrow hiding
- Grabbable anchors for repositioning precisely in real-world
- Home mode and anchor-management mode
- Contextual controller instructions in the UI

---

## Technologies Used
- Unity
- C#
- Meta Quest 3
- Meta XR / Oculus Interaction SDK
- Adaptive UI Toolkit (AUIT)

---

## Controls
- Right Grip -> Open/close anchor management
- X -> Create anchor
- Y -> Delete selected anchor
- Right Joystick Up/Down -> Navigate saved anchors / label list
- Right Trigger -> Confirm selected label
- Left controller Grip near anchor -> Grab and reposition anchor

---

## Project Workflow
### Home Mode
- User sees the passthrough room
- A home instruction label is shown
- Right Grip opens anchor management

### Anchor Management Mode
- Saved anchor list is shown
- User can browse anchors using the right joystick
- The selected anchor becomes the current target for the arrow

### Creating an Anchor
1. Press X
2. A new anchor is created in front of the user
3. Label selection menu opens
4. Use Right Joystick Up/Down to choose a label
5. Press Right Trigger to confirm
6. The anchor is added to the saved anchor list

### Deleting an Anchor
1. Select an anchor in the saved list
2. Press Y
3. The selected anchor is removed (no need to point or be near to selected anchor)

### Repositioning an Anchor
- Spawned anchors are grabbable
- The user can grab and reposition them after creation using left controller grip
- To grip an anchor user must touch the anchor with left controller and then hold grip to drad it

---

## AUIT Components Used
### Adaptation Objectives
- Target Distance Objective
- Look Towards Objective
- Field of View Objective (tested in adaptation experiments)

### Adaptation Trigger
- Continuous Optimization Trigger

### Transition Properties
- Curve Rotation Transition
- Curve Position Transition

### Context Sources
- Transform Context Source
- Runtime Transform Context Source

---

## Other Adaptive Mechanisms Used (custom)
- Distance-based arrow scaling
- Distance-based arrow opacity
- Near-target arrow hiding
- Menu dimming for focus
- Dynamic selection highlighting
- Runtime target switching
- Mode-based UI switching
- Controller-based input gating
- Grabbable anchor repositioning

---

## Requirements
- Unity version: 6000.3.9f1
- Meta Quest 3
- Android build support installed through Unity Hub
- Meta XR / Oculus packages resolved in the project
- AUIT-complete toolkit package
- Meta XR Installation SDK
- Meta XR All-In-One SDK

---

## Installation
1. Clone or download this repository
2. Open the project in Unity
3. Let Unity reimport packages and assets
4. Open the main demo scene (Assets/Scenes/AUIT_9_Final_Working)
5. Connect Meta Quest 3 (using USB cable or AirLink)
6. Build and Run to the headset

---

## Important Notes
- The final demo supports up to 4 anchors
- Preset labels are used instead of free text input
- The project does not use object detection or computer vision
- AUIT was mainly used on the guidance/arrow side for stability

---

## Repository Structure
- `Assets/` -> scenes, scripts, prefabs, materials, UI, XR setup, AUIT
- `Packages/` -> Unity package dependencies
- `ProjectSettings/` -> Unity project settings

---

## Authors
- Vaibhav Karande
- Brian Thomas

---

## Usage
This repository is shared for academic review and seminar demonstration purposes.