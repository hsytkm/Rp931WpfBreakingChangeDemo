 # Breaking change in Ver 9.3.1

## Introduction

I have limited knowledge of schedulers.

I think a breaking change has occurred. If there are any problems with my implementation, please let me know.

 ## Platform with bug

WPF

 ## Description

After the timer start of `ReactiveTimer` in Rp Ver9.3.1, subsequent processing is **not** executed.

 ## Steps to Reproduce

1. Set `ReactivePropertyWpfScheduler` to Rp’s scheduler in `Application.Startup`.
2. Create `ReactiveTimer` with Rp’s default scheduler.
3. Start the timer of the created `ReactiveTimer`.

 ## Expected behavior

Subsequent processing is executed after `ReactiveTimer` starts.

 ## Actual behavior

Subsequent processing is **not** executed after `ReactiveTimer `starts.


 ## Combination confirmation results

|                                 | 9.3.0 | 9.3.1  |
| ------------------------------- | ----- | ------ |
| SynchronizationContextScheduler | OK    | OK     |
| ReactivePropertyWpfScheduler    | OK    | **NG** |

## Environment

- VisualStudio 2022 17.7.6
- net48, net6.0-windows
- ReactiveProperty.WPF 9.3.1

## Reproduction Repo

