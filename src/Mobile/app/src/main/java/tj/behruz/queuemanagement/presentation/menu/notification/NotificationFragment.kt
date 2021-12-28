package tj.behruz.queuemanagement.presentation.menu.notification

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import tj.behruz.queuemanagement.databinding.NotificationFragmentBinding
import tj.behruz.queuemanagement.presentation.extension.showActionbar

class NotificationFragment : Fragment() {

    private lateinit var binding: NotificationFragmentBinding

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        binding = NotificationFragmentBinding.inflate(layoutInflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        showActionbar("Уводомление")
    }

}