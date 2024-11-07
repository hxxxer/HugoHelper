# HugoHelper

---

这个项目是基于VS的.NET框架开发的，目的是方便我使用Hugo搭建的个人博客。

Hugo相关的命令都是通过启动一个ps7进程，然后再输入相关的命令。

# 目前功能

- 创建blog，默认名称为当前时间，可在文本框修改
- 启动本地Server服务，用于测试查看
- 构建上传到Github pages的静态网页
- 清理缓存垃圾
- git管理窗口（只有空壳）

# 待做

- [ ] 完善git管理窗口

- [x] 加入配置文件功能，路径等内容不再硬编码

- [ ] 加入GitHub action自动构建功能，方便发布