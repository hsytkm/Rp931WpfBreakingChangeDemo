 # Ver 9.3.1 で破壊的変更



## はじめに

私はスケジューラの知識が乏しいす。破壊的変更は発生していると思っていますが、そもそもの私の実装に問題がありましたらご指摘下さい。

 ## バグが発生するプラットフォーム

WPF

 ## 詳細

WPF の Rp Ver9.3.1 より `ReactiveTimer` のタイマー開始後に後続の処理が実行されません。

## 再現リポ



 ## 再現手順

1. Application.Startup にて、Rp のスケジューラに `ReactivePropertyWpfScheduler` を設定します。
2. Rp のデフォルトスケジューラで `ReactiveTimer` を生成します。
3. 生成した `ReactiveTimer` の Timer をスタートします。

 ## 期待される動作

ReactiveTimer の スタート後に後続の処理が実行される。

 ## 実際の動作

ReactiveTimer の スタート後に後続の処理が実行されない。


 ## 確認した組み合わせ
|                                 | 9.3.0 | 9.3.1 |
| ------------------------------- | ----- | ----- |
| SynchronizationContextScheduler | OK    | OK    |
| ReactivePropertyWpfScheduler    | OK    | NG    |

## 確認環境

- VisualStudio 2022 17.7.6
- net48, net6.0-windows
- ReactiveProperty.WPF 9.3.1