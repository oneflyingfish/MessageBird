# MessageBird
基于C#的GUI程序，高仿QQ。<br>
声明：此程序仅供学习参考，无意冒犯腾讯QQ，若有不对，请联系作者删除。

## 作者留言：
这个项目属于笔者非常早期的代码，当时技术储备十分有限，后来也一直没有时间修正，通信协议这块采用Json+Base64传输，会更容易一点

## 开发说明：  
开发环境：`Visual Stdio 2017 + Windows 10 + .net framework 4.5.2`  
开发语言：`C#`  

## 文件说明：
文件包含：客户端全部，不含服务器代码

## 部分功能说明：
* 账户
  * 注册账户
  * 修改账户
  * 发送邮件验证码
  * 控制邮件发送频率
  
* 登录
  * 根据账户获取图像
  * 验证账户正确性，触发登录
  * 记住密码
  * 隐藏密码
  * 自动登录
  
* 主界面：
  * 显示基本信息
  * 搜索群聊/好友
  * 搜索消息（相关代码被注释）
  * 展示群聊、好友
  * 展示消息及其基本信息
  * 添加好友/群聊入口
  
* 聊天界面：
  * 加载历史消息
  * 显示新消息
  * 编辑消息
  * 搜索消息
  * 匹配好友/群聊
  * 显示对方基本信息
  
## 项目基本定位：
服务器尚未完成，客户端需要在整体调试中测试是否存在问题，部分功能简写了未来可以作为优化方向。

## 效果图：
* 登录：  
![登录](https://github.com/oneflyingfish/a_flying_fish/blob/master/Pictures/MessageBird/sign_in.png)
* 主界面:  
![好友/群聊](https://github.com/oneflyingfish/a_flying_fish/blob/master/Pictures/MessageBird/info.png)
![消息](https://github.com/oneflyingfish/a_flying_fish/blob/master/Pictures/MessageBird/news.png)
* 聊天界面：  
![聊天](https://github.com/oneflyingfish/a_flying_fish/blob/master/Pictures/MessageBird/chat.png)

