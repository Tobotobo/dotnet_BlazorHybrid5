# dotnet_BlazorHybrid5

## 概要
* 試行錯誤中
* ベース: [dotnet_BlazorHybrid4](https://github.com/Tobotobo/dotnet_BlazorHybrid4)
* Wpf 復活！
* 不要なファイルを削除
* Web、Forms、Wpf でファイル構成がほぼ同じになるよう修正
* profile 更新

## ターゲット
* まだデスクトップアプリ開発が必用だが、Web アプリやスマホアプリ開発につなげていきたい
* 開発環境が Windows の Visual Studio に縛られているのを脱却したい

## 想定する使い方
* ローカルに Docker 環境を作るか、外部の Docker がインストールされた環境に Remote-SSH で接続し DevContainer で開発する  
  ※DevContainer を用いずにローカルに直接 .NET 8 をインストールして開発も可能

* View の実装は、デバッグ実行「.NET Core Launch (Web)」やタスク「👀watch-web」を用いてブラウザでプレビューしながら行う  
  ※要ポートフォワーディング

* 一通りできたらタスク「📤publish-forms」や「📤publish-wpf」で実行ファイルを作成する  
  ※スマホアプリは未実装（今後追加したい）

## 参考サイト
感謝！
* [ねこじょーかー/Blazor HybridとBlazor Web AppのUIをRCLで共通化する手順](https://blazor-master.com/blazor-hybrid-maui-rcl/)
* [nekojoker/BlazorHybrid](https://github.com/nekojoker/BlazorHybrid)
    > .NET MAUI Blazor アプリと Blazor Web App の Razor コンポーネントや静的資産を Razor クラスライブラリで共通化したプロジェクトです。  
    > .NET 8 に対応しています。

## 環境
```
> dotnet --info   
.NET SDK:
 Version:           8.0.204   
 Commit:            c338c7548c
 Workload version:  8.0.200-manifests.c4df6daf

ランタイム環境:
 OS Name:     Windows
 OS Version:  10.0.19045
 OS Platform: Windows
 RID:         win-x64
 Base Path:   C:\Program Files\dotnet\sdk\8.0.204\
```

## メモ

### コマンド
* デバッグ実行 `F5`
  * .NET Core Launch (Web)
  * .NET Core Attach
* タスク
  * 👀watch-web `Ctrl + Shift + B`
  * 📤publish-forms
  * 📤publish-wpf
  * 🛠️build-web
  * 🧹clean

※ publish ではワークスペース直下に publish フォルダを作成しそこに出力する。

### Wpf 追加
```
dotnet new wpf -o ./BlazorHybrid.Wpf
dotnet sln add ./BlazorHybrid.Wpf
dotnet add ./BlazorHybrid.Wpf reference ./BlazorHybrid.View
dotnet add ./BlazorHybrid.Wpf package Microsoft.AspNetCore.Components.WebView.Wpf --version 8.0.20
```