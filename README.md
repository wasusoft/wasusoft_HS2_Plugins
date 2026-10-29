# wasusoft_HS2_Plugins

Small BepInEx plugins for HoneySelect2. Each plugin is a separate DLL, so you can install only the ones you want.

[日本語の説明は下にあります](#日本語)

If you like these plugins, you can support development on [Patreon](https://www.patreon.com/wasusoft). All plugins stay free.

| Plugin | What it does | Works in |
|---|---|---|
| [HS2_OfficialVRFix](#hs2_officialvrfix) | Makes the thumbsticks work in the official VR mode on Meta Quest + SteamVR, and adds an A/X button for the finish menu | Official VR |
| [HS2_SpeedBoost](#hs2_speedboost) | Raises the maximum animation speed in H scenes | Normal game and official VR |

## Requirements

- HoneySelect2 (tested on Libido DX, Steam version 1.2.3)
- BepInEx 5 (included in HF Patch)

### Tested setups

| Plugin | Tested on |
|---|---|
| HS2_OfficialVRFix | Quest 3 + Virtual Desktop + SteamVR |
| HS2_SpeedBoost | Normal game, official VR (Quest 3 + Virtual Desktop) |

Other headsets and setups may work but are not tested yet. If you try one, please tell me in [Issues](../../issues) whether it worked, and I will add it to this list.

## Install

1. Download the DLLs you want from the [Releases](../../releases) page.
2. Put them in `BepInEx\plugins\wasusoft\` inside the game folder (create the folder if needed). The release zips already have this folder structure, so you can also extract them into the game folder.

To uninstall, delete the DLL.

Settings can be changed in-game with ConfigurationManager (F1, included in HF Patch) or in the files in `BepInEx\config\`.

## HS2_OfficialVRFix

For the official VR mode (`HoneySelect2VR.exe`) with **Meta Quest through SteamVR** (for example Virtual Desktop or Steam Link). Tested on Quest 3 + Virtual Desktop.

**Sticks:** the official VR mode checks the headset name. If it contains "Quest", the game reads the sticks through Oculus input (OVRInput). Under SteamVR that input is always zero, so the sticks do nothing (for example, you cannot change the speed). This plugin reads the sticks from SteamVR instead.

**Finish button (A / X):** normally you have to point at the finish gauge to use it. With this plugin you can also use the A or X button:

- **Tap A/X**: finish with the type shown on the gauge.
- **Hold A/X + stick up/down**: change the finish type. The speed does not change while you hold the button.

Setting: `FinishButton` (default `true`) in `wasusoft.hs2.officialvrfix.cfg`.

## HS2_SpeedBoost

The game picks the speed between a minimum and a maximum with the mouse wheel (or the stick in VR). This plugin multiplies only the maximum, so slow speeds stay the same.

Setting: `MaxMultiplier` (default `2`, from `1` to `5`) in `wasusoft.hs2.speedboost.cfg`.

## Bug reports and requests

Please use [Issues](../../issues). I answer once a week, so please be patient. When reporting a bug, include your headset, how you connect it (Virtual Desktop, Steam Link, ...), and `BepInEx\LogOutput.log`.

## Official download locations

These plugins are only distributed on **this GitHub page (Releases)**. The only official support page is [patreon.com/wasusoft](https://www.patreon.com/wasusoft). Do not trust copies or support pages on other sites. Each release lists the SHA256 hash of every DLL so you can check the files.

## Build from source

```
dotnet build src/HS2_OfficialVRFix -c Release -p:GameDir="<your HoneySelect2 folder>"
dotnet build src/HS2_SpeedBoost -c Release -p:GameDir="<your HoneySelect2 folder>"
```

The game's DLLs are referenced from your own game folder and are not included in this repository.

## License

MIT. This project is not affiliated with the game's developer.

---

## 日本語

HoneySelect2 用の小さな BepInEx プラグイン集です。機能ごとに別の DLL なので、欲しいものだけ入れられます。

気に入ったら [Patreon](https://www.patreon.com/wasusoft) で応援してもらえるとうれしいです。プラグインはこれからもすべて無料です。

| プラグイン | できること | 動く場所 |
|---|---|---|
| HS2_OfficialVRFix | Meta Quest＋SteamVR で公式VRのスティックが効かない問題を直す。A／X ボタンでフィニッシュ操作 | 公式VR |
| HS2_SpeedBoost | Hシーンの速さの上限を上げる | 通常版・公式VR |

### 必要なもの

- HoneySelect2（Libido DX、Steam版 1.2.3 で確認）
- BepInEx 5（HF Patch に含まれています）

### 確認済みの環境

| プラグイン | 確認した環境 |
|---|---|
| HS2_OfficialVRFix | Quest 3＋Virtual Desktop＋SteamVR |
| HS2_SpeedBoost | 通常版、公式VR（Quest 3＋Virtual Desktop） |

ほかの機種・接続方法でも動くかもしれませんが、まだ確認していません。試した方は、動いたかどうかを [Issues](../../issues) で教えてください。この表に追加します。

### 入れ方

1. [Releases](../../releases) から欲しい DLL をダウンロード
2. ゲームのフォルダの `BepInEx\plugins\wasusoft\` に入れる（フォルダが無ければ作る）。リリースの zip はこの形になっているので、ゲームのフォルダにそのまま展開しても入ります

外すときは、その DLL を消してください。設定はゲーム中の ConfigurationManager（F1。HF Patch に含まれています）か、`BepInEx\config\` のファイルで変えられます。

### HS2_OfficialVRFix

公式VR（`HoneySelect2VR.exe`）を **Meta Quest＋SteamVR**（Virtual Desktop、Steam Link など）で遊ぶ人向けです。Quest 3＋Virtual Desktop で確認しています。

- **スティック**：公式VRは、ヘッドセットの名前に「Quest」が入っていると Oculus 用の入力でスティックを読みます。SteamVR ではこの入力が常に 0 なので、スティックが効きません。このプラグインは SteamVR から読み直します。
- **フィニッシュボタン（A／X）**：本来はゲージにポインタを当てないと操作できませんが、A か X ボタンでも操作できます。
  - **短く押す**：ゲージに出ている種類でフィニッシュ
  - **押しながらスティック上下**：種類を切り替える（押している間は速さが変わりません）
  - 設定：`wasusoft.hs2.officialvrfix.cfg` の `FinishButton`（初期値 `true`）

### HS2_SpeedBoost

ゲームはホイール（VR ではスティック）で、最小〜最大の間の速さを決めます。このプラグインは**最大だけ**を倍にするので、遅い速さはそのままです。

- 設定：`wasusoft.hs2.speedboost.cfg` の `MaxMultiplier`（初期値 `2`、`1`〜`5`）

### 不具合の報告・要望

[Issues](../../issues) で受け付けています。返事は週1回まとめてなので、少しお待ちください。不具合の報告には、ヘッドセットの機種、つなぎ方（Virtual Desktop、Steam Link など）、`BepInEx\LogOutput.log` を付けてください。

### 配布場所

配布は**この GitHub（Releases）だけ**です。公式の支援ページは [patreon.com/wasusoft](https://www.patreon.com/wasusoft) だけです。ほかのサイトにある配布物や支援ページは使わないでください。リリースごとに DLL の SHA256 を載せています。
