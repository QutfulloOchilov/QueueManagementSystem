package tj.behruz.queuemanagement.presentation.salons

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.core.os.bundleOf
import androidx.core.view.isVisible
import androidx.fragment.app.Fragment
import androidx.fragment.app.viewModels
import tj.behruz.queuemanagement.R
import tj.behruz.queuemanagement.databinding.AllSalonsFragmentBinding
import tj.behruz.queuemanagement.presentation.extension.navigateToScreen
import tj.behruz.queuemanagement.presentation.extension.showActionbar

class AllSalonsFragment : Fragment() {

    private lateinit var _binding: AllSalonsFragmentBinding
    private val binding get() = _binding
    private val viewModel: SalonsViewModel by viewModels()
    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = AllSalonsFragmentBinding.inflate(layoutInflater, container, false)
        return binding.root
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        showActionbar()
        viewModel.getSalon().observe(viewLifecycleOwner) { salons ->
            with(binding) {
                shimmer.isVisible = false
                queueRecyclerView.isVisible = true
                queueRecyclerView.adapter = SalonsAdapter(salons) {
                    navigateToScreen(
                        R.id.action_nav_salons_to_salonDescriptionFragment,
                        bundleOf("title" to it.name)
                    )
                }
            }

        }
    }

}