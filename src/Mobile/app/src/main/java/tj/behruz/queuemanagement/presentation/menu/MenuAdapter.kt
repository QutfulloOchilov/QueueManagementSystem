package tj.behruz.queuemanagement.presentation.menu

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import tj.behruz.queuemanagement.databinding.MenuItemBinding
import tj.behruz.queuemanagement.domain.entity.Menu

class MenuAdapter(private val menus: List<Menu>, private val itemHandler: (Menu) -> Unit) :
    RecyclerView.Adapter<MenuAdapter.MenuViewHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MenuViewHolder {
        val binding = MenuItemBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return MenuViewHolder(binding)
    }

    override fun onBindViewHolder(holder: MenuViewHolder, position: Int) {
        val currentMenu = menus[position]
        holder.setMenu(currentMenu)
        holder.itemView.setOnClickListener {
            itemHandler.invoke(currentMenu)
        }
    }

    override fun getItemCount() = menus.size

    inner class MenuViewHolder(private val binding: MenuItemBinding) :
        RecyclerView.ViewHolder(binding.root) {
        fun setMenu(menu: Menu) {
            with(binding) {
                menuIcon.setImageResource(menu.icon)
                menuName.text = menu.name
            }
        }
    }


}