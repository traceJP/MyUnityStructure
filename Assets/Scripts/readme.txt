客户端架构说明

命名空间：
1、起到隔离类的作用
2、起到分类的作用

命名空间的层次：
--- 作用：最高层可以知道（拿到）所有比它底层的存在，同层之间不能互相知道其存在（例如Models之间不能互相调用，Monster不能直接调用Role）

App                                    最高层 整个程序的主入口
Controller                             Controller层是游戏的所有业务，可以看作是App层的分流，将App层的所有业务都提取出到Controller层
Facades                                门面缓存类 All开头的类
   - Manager | Repository | Assets
Event | Models                         角色 怪物等    Event和Models是同层

Entities
    高层                    例如 Role（*继承IRole） | Monster | Projectile(子弹)
    底层                    例如 Skill | Inventory(背包) ， 只能依赖与高层，但又不能知道高层，但可以知道高层的接口
    最底层（又是高层的接口）    例如 IRole
    // 三层之间相当于一个循环

流程：
1、App 控制 Controller 、 Controller 通过调用 Facades和Manager 对 Models进行操作
2、其中Controller之间互相通过 Event 进行通信

架构作用：
1、分离逻辑，让代码更可读、可改
2、控制顺序，让程序按自己知道的顺序来执行，确定执行的顺序




