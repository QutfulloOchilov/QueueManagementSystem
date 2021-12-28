package tj.behruz.queuemanagement.presentation.menu

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import com.google.android.material.snackbar.Snackbar
import tj.behruz.queuemanagement.R
import tj.behruz.queuemanagement.databinding.MenuFragmentBinding
import tj.behruz.queuemanagement.domain.entity.Menu
import tj.behruz.queuemanagement.presentation.extension.hideActionbar
import tj.behruz.queuemanagement.presentation.extension.navigateToScreen

class MenuFragment : Fragment() {

    private lateinit var _binding: MenuFragmentBinding
    private val binding get() = _binding

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = MenuFragmentBinding.inflate(layoutInflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        hideActionbar()
        setUpMenu()
    }

    private fun setUpMenu() {
        val menus = listOf(
            Menu("Профиль", R.drawable.ic_notifications_icon, MenuAction.PROFILE),
            Menu("Безапосность", R.drawable.ic_lock_icon, MenuAction.SECURITY),
            Menu("Уводемление", R.drawable.ic_notifications_icon, MenuAction.NOTIFICATION),
            Menu("Помощь", R.drawable.ic_help_icon, MenuAction.HELP),
            Menu("Поделиться", R.drawable.ic_share_icon, MenuAction.SHARE),
            Menu("Выход", R.drawable.ic_log_out_icon, MenuAction.LOGOUT)
        )
        binding.menuRV.adapter = MenuAdapter(menus, this::menuItemHandler)
    }

    private fun menuItemHandler(menu: Menu) {
        when (menu.action) {
            MenuAction.PROFILE -> {
                navigateToScreen(R.id.action_nav_menu_to_profileFragment)
            }
            MenuAction.SECURITY -> {
                inDevelopment()
            }
            MenuAction.NOTIFICATION -> {
                navigateToScreen(R.id.action_nav_menu_to_notificationFragment)
            }
            MenuAction.HELP -> {
                inDevelopment()
            }
            MenuAction.SHARE -> {
                shareApp()
            }
            MenuAction.LOGOUT -> {
                inDevelopment()
            }

        }
    }

    private fun shareApp() {
        val sendIntent: Intent = Intent().apply {
            action = Intent.ACTION_SEND
            putExtra(Intent.EXTRA_TEXT, "This is my text to send.")
            type = "text/plain"
        }

        val shareIntent = Intent.createChooser(sendIntent, null)
        startActivity(shareIntent)
    }


    private fun inDevelopment() {
        //just for test
        Snackbar.make(binding.appBar, "IN development", Snackbar.LENGTH_LONG).show()
    }

}