package tj.behruz.queuemanagement.domain.entity

import tj.behruz.queuemanagement.presentation.menu.MenuAction

data class Menu(
    val name:String,
    val icon:Int,
    val action:MenuAction
)
