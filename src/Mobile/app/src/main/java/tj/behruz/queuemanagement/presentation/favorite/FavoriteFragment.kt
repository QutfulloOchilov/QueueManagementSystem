package tj.behruz.queuemanagement.presentation.favorite

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.core.view.isVisible
import androidx.fragment.app.Fragment
import androidx.fragment.app.viewModels
import tj.behruz.queuemanagement.databinding.FavoriteFragmentBinding
import tj.behruz.queuemanagement.presentation.extension.hideActionbar

class FavoriteFragment : Fragment() {

    private lateinit var _binding: FavoriteFragmentBinding
    private val binding get() = _binding
    private val viewModel: FavoriteViewModel by viewModels()
    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FavoriteFragmentBinding.inflate(layoutInflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        hideActionbar()
        viewModel.getFavorites()
        viewModel.favorite.observe(viewLifecycleOwner) {
            with(binding) {
                binding.shimmerLayout.stopShimmer()
                binding.shimmerLayout.isVisible = false
                binding.favoriteRV.adapter = FavoriteAdapter()
                binding.favoriteRV.isVisible = true
            }

        }
    }

}