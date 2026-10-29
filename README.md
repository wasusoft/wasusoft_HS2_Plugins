# wasusoft_HS2_Plugins

Small plugins for **HoneySelect2**. Free to use.

**日本語の説明 → [ダウンロードと入れ方（日本語）](#日本語)**

## ⬇ Download

Click a file name to download it. You can install one or both.

| Download | What it does | For |
|---|---|---|
| ⬇ **[HS2_OfficialVRFix.zip](https://github.com/wasusoft/wasusoft_HS2_Plugins/releases/latest/download/HS2_OfficialVRFix.zip)** | Makes the thumbsticks work in the official VR mode with Meta Quest, and lets you finish with the A/X button | Official VR (Meta Quest) |
| ⬇ **[HS2_SpeedBoost.zip](https://github.com/wasusoft/wasusoft_HS2_Plugins/releases/latest/download/HS2_SpeedBoost.zip)** | Makes the fastest H scene speed faster | Everyone (normal game and VR) |

These links always download the newest version.

> 💖 **Like these plugins?** They are free, and they stay free. If they helped you, please consider supporting me on **[Patreon](https://www.patreon.com/wasusoft)**. Supporters get new plugins **early** (from $3) and can **vote** on what I make next (from $10).

## How to install (3 steps)

**Before you start:** you need BepInEx. If you installed **HF Patch**, you already have it. (Check: there is a folder named `BepInEx` in the game folder.)

1. **Open the game folder.** In Steam, right-click HoneySelect2 → **Manage** → **Browse local files**.
2. **Double-click the downloaded zip** to open it. You will see a folder named `BepInEx`.
3. **Drag the `BepInEx` folder into the game folder.** If Windows asks, choose **Replace the files**. (This only adds the plugin. Your saves and characters are not touched.)

Done. Start the game. Enjoy! If it works for you, a ⭐ on this page or [Patreon](https://www.patreon.com/wasusoft) support helps a lot.

> ⚠ Do not use "Extract All" with the default location. It makes an extra folder, and the plugin will not load.
>
> To check: the file should be at `(game folder)\BepInEx\plugins\wasusoft\HS2_OfficialVRFix.dll` (or `HS2_SpeedBoost.dll`).

## How to uninstall

Delete the file in `(game folder)\BepInEx\plugins\wasusoft\`.

---

## Details

### Requirements

- HoneySelect2 (tested on Libido DX, Steam version 1.2.3)
- BepInEx 5 (included in HF Patch)

### Tested setups

| Plugin | Tested on |
|---|---|
| HS2_OfficialVRFix | Quest 3 + Virtual Desktop + SteamVR |
| HS2_SpeedBoost | Normal game, official VR (Quest 3 + Virtual Desktop) |

Other headsets and setups may work but are not tested yet. If you try one, please tell me in [Issues](../../issues) whether it worked, and I will add it to this list.

Settings can be changed in-game with ConfigurationManager (F1, included in HF Patch) or in the files in `BepInEx\config\`.

### HS2_OfficialVRFix

For the official VR mode (`HoneySelect2VR.exe`) with **Meta Quest through SteamVR** (for example Virtual Desktop or Steam Link). Tested on Quest 3 + Virtual Desktop.

**Sticks:** the official VR mode checks the headset name. If it contains "Quest", the game reads the sticks through Oculus input (OVRInput). Under SteamVR that input is always zero, so the sticks do nothing (for example, you cannot change the speed). This plugin reads the sticks from SteamVR instead.

**Finish button (A / X):** normally you have to point at the finish gauge to use it. With this plugin you can also use the A or X button:

- **Tap A/X**: finish with the type shown on the gauge.
- **Hold A/X + stick up/down**: change the finish type. The speed does not change while you hold the button.

Setting: `FinishButton` (default `true`) in `wasusoft.hs2.officialvrfix.cfg`.

### HS2_SpeedBoost

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

**HoneySelect2** 用の小さなプラグインです。無料で使えます。

### ⬇ ダウンロード

ファイル名をクリックするとダウンロードできます。片方だけでも、両方でも入れられます。

| ダウンロード | できること | 対象 |
|---|---|---|
| ⬇ **[HS2_OfficialVRFix.zip](https://github.com/wasusoft/wasusoft_HS2_Plugins/releases/latest/download/HS2_OfficialVRFix.zip)** | 公式VRを Meta Quest で遊ぶと**スティックが効かない**問題を直す。**A／X ボタンでフィニッシュ**できる | 公式VR（Meta Quest） |
| ⬇ **[HS2_SpeedBoost.zip](https://github.com/wasusoft/wasusoft_HS2_Plugins/releases/latest/download/HS2_SpeedBoost.zip)** | Hシーンの**一番速い速さをもっと速く**する | 全員（通常版・VR） |

このリンクは、いつでも最新版がダウンロードされます。

> 💖 **気に入ってもらえたら** — プラグインは無料で、これからも無料です。役に立ったら **[Patreon](https://www.patreon.com/wasusoft)** で応援してもらえるとうれしいです。支援してくれた方は、新しいプラグインを**先に使え**（$3から）、次に作るものの**投票**にも参加できます（$10から）。

### 入れ方（3ステップ）

**始める前に：** BepInEx が必要です。**HF Patch** を入れていれば、もう入っています（確認：ゲームのフォルダに `BepInEx` というフォルダがあればOK）。

1. **ゲームのフォルダを開く。** Steam で HoneySelect2 を右クリック →「**管理**」→「**ローカルファイルを閲覧**」
2. **ダウンロードした zip をダブルクリック**して開く。中に `BepInEx` というフォルダが見えます
3. **その `BepInEx` フォルダを、ゲームのフォルダにドラッグ**する。Windows に聞かれたら「**ファイルを置き換える**」を選ぶ（プラグインが追加されるだけで、セーブやキャラは変わりません）

これで完了です。ゲームを起動してください。うまく動いたら、このページの ⭐（スター）や [Patreon](https://www.patreon.com/wasusoft) での応援が大きな励みになります。

> ⚠「すべて展開」をそのまま使わないでください。余計なフォルダができて、プラグインが読み込まれません。
>
> 確認：`（ゲームのフォルダ）\BepInEx\plugins\wasusoft\HS2_OfficialVRFix.dll`（または `HS2_SpeedBoost.dll`）があれば成功です。

### 外し方

`（ゲームのフォルダ）\BepInEx\plugins\wasusoft\` の中のファイルを消してください。

---

### くわしい説明

**必要なもの**：HoneySelect2（Libido DX、Steam版 1.2.3 で確認）、BepInEx 5（HF Patch に含まれています）

**確認済みの環境**

| プラグイン | 確認した環境 |
|---|---|
| HS2_OfficialVRFix | Quest 3＋Virtual Desktop＋SteamVR |
| HS2_SpeedBoost | 通常版、公式VR（Quest 3＋Virtual Desktop） |

ほかの機種・接続方法でも動くかもしれませんが、まだ確認していません。試した方は、動いたかどうかを [Issues](../../issues) で教えてください。

設定はゲーム中の ConfigurationManager（F1。HF Patch に含まれています）か、`BepInEx\config\` のファイルで変えられます。

#### HS2_OfficialVRFix

公式VR（`HoneySelect2VR.exe`）を **Meta Quest＋SteamVR**（Virtual Desktop、Steam Link など）で遊ぶ人向けです。Quest 3＋Virtual Desktop で確認しています。

- **スティック**：公式VRは、ヘッドセットの名前に「Quest」が入っていると Oculus 用の入力でスティックを読みます。SteamVR ではこの入力が常に 0 なので、スティックが効きません。このプラグインは SteamVR から読み直します。
- **フィニッシュボタン（A／X）**：本来はゲージにポインタを当てないと操作できませんが、A か X ボタンでも操作できます。
  - **短く押す**：ゲージに出ている種類でフィニッシュ
  - **押しながらスティック上下**：種類を切り替える（押している間は速さが変わりません）
  - 設定：`wasusoft.hs2.officialvrfix.cfg` の `FinishButton`（初期値 `true`）

#### HS2_SpeedBoost

ゲームはホイール（VR ではスティック）で、最小〜最大の間の速さを決めます。このプラグインは**最大だけ**を倍にするので、遅い速さはそのままです。

- 設定：`wasusoft.hs2.speedboost.cfg` の `MaxMultiplier`（初期値 `2`、`1`〜`5`）

### 不具合の報告・要望

[Issues](../../issues) で受け付けています。返事は週1回まとめてなので、少しお待ちください。不具合の報告には、ヘッドセットの機種、つなぎ方（Virtual Desktop、Steam Link など）、`BepInEx\LogOutput.log` を付けてください。

### 配布場所

配布は**この GitHub（Releases）だけ**です。公式の支援ページは [patreon.com/wasusoft](https://www.patreon.com/wasusoft) だけです。ほかのサイトにある配布物や支援ページは使わないでください。リリースごとに DLL の SHA256 を載せています。
