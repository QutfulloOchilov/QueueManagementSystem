package tj.behruz.queuemanagement.presentation.master

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.core.os.bundleOf
import androidx.fragment.app.Fragment
import tj.behruz.queuemanagement.R
import tj.behruz.queuemanagement.databinding.ServiveFragmentBinding
import tj.behruz.queuemanagement.presentation.extension.navigateToScreen

class MasterFragment : Fragment() {

    private lateinit var binding: ServiveFragmentBinding

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        binding = ServiveFragmentBinding.inflate(layoutInflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        binding.RV.adapter = MasterAdapter() {
            navigateToScreen(
                R.id.action_nav_salon_description_to_scheduleFragment,
                bundleOf("title" to it)
            )
        }
    }

}