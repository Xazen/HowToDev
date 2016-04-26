using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlidesCommandController : MonoBehaviour
{
    public int NextSceneBuildIndex = -1;

    private List<SlideCommand> _commands = new List<SlideCommand>();
    private List<SlideCommand> _activeCommands = new List<SlideCommand>();

    private int _triggeredCommandCount;

    public void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            SlideCommand command = child.GetComponent<SlideCommand>();
            if (command != null)
            {
                _commands.Add(command);
            }
        }
    }

    public void Update()
    {
        TriggerCommand();
    }

    private void TriggerCommand()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // trigger next slide command
            if (_triggeredCommandCount < _commands.Count)
            {
                // disable previous commands
                RemoveAllActiveCommands();

                // trigger next command
                SlideCommand currenctCommand = _commands[_triggeredCommandCount];
                TriggerCommand(currenctCommand);

                // trigger more commands when trigger with previous is true
                bool checkForMoreCommand = true;
                while (_triggeredCommandCount < _commands.Count && checkForMoreCommand)
                {
                    // get next command
                    SlideCommand nextCommand = _commands[_triggeredCommandCount];

                    // trigger it when trigger with previous is true
                    if (nextCommand.TriggerWithPrevious)
                    {
                        TriggerCommand(nextCommand);
                    }

                    // trigger with previous is false, stop checking for more
                    else
                    {
                        checkForMoreCommand = false;
                    }
                }
            }

            // open next scene
            else if (NextSceneBuildIndex != -1)
            {
                SceneManager.LoadScene(NextSceneBuildIndex);
            }
        }
    }

    private void RemoveAllActiveCommands()
    {
        if (_activeCommands.Count > 0)
        {
            foreach (SlideCommand slideCommand in _activeCommands)
            {
                slideCommand.enabled = false;
            }
            _activeCommands.Clear();
        }
    }

    private void TriggerCommand(SlideCommand command)
    {
        command.Execute();
        _activeCommands.Add(command);
        _triggeredCommandCount++;
    }
        
}
