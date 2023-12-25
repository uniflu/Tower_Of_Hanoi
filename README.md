# ハノイの塔
- パズルゲームの一種です(<a href="https://ja.wikipedia.org/wiki/%E3%83%8F%E3%83%8E%E3%82%A4%E3%81%AE%E5%A1%94">wiki</a>)。
- 3~7段に設定して遊べます。
<br>

## 動作環境など
- WebGLの780×405で動作するように作成しました。
<br>

## BGM・効果音について
- 本来は効果音・BGM付ですが、<b>フリー素材の著作権の都合上消しました</b>。
- 「TitleScene」の「TitleDirector」、「MainScene」の「Director」オブジェクトにお好みの音源を割り当ててあげてください。
<br><br>

## Sceneについて
- スリープ状態にしてから数時間経つと指定時刻になってもアラームが鳴らない。
- スマホを5回振ったら止められるようにしたいが、2回とかで止まるときもある。
<br><br>

## 参考サイトなど
- ローカル通知の基礎：https://youtu.be/26TTYlwc6FM
- 指定時刻のローカル通知：https://youtu.be/T6Wg0AmIESE
<br><br>

## 使用パッケージ(カッコ内はバージョン)
- flutter_local_notifications(15.0.0)：ローカル通知。バージョンを15以降にすると指定時刻での通知が上手くできませんでした。
- flutter_datetime_picker_plus(2.1.0)：時刻選択。
- timezone(^0.9.2)：タイムゾーンの取得?
- flutter_ringtone_player(3.2.0)：アラームを鳴らす。
- android_alarm_manager_plus(3.0.3)：アンドロイド用で指定時刻にバックグラウンドで処理が可能。
<br><br>
