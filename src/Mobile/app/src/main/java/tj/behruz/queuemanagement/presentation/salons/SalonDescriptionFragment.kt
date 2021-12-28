package tj.behruz.queuemanagement.presentation.salons

import android.os.Bundle
import android.view.*
import androidx.core.os.bundleOf
import androidx.core.view.isVisible
import androidx.fragment.app.Fragment
import tj.behruz.queuemanagement.R
import tj.behruz.queuemanagement.databinding.SalonDescriptionBinding
import tj.behruz.queuemanagement.presentation.extension.showActionbar
import tj.behruz.queuemanagement.presentation.feedback.FeedbackBottomSheet
import tj.behruz.queuemanagement.presentation.master.MasterFragment

class SalonDescriptionFragment : Fragment() {

    private lateinit var _binding: SalonDescriptionBinding
    private val binding get() = _binding
    private lateinit var salonViewPagerAdapter: SalonViewPagerAdapter
    private val title by lazy(LazyThreadSafetyMode.NONE) {
        requireArguments().getString("title")
    }

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = SalonDescriptionBinding.inflate(layoutInflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        setHasOptionsMenu(true)

        showActionbar(title)
        salonViewPagerAdapter = SalonViewPagerAdapter(childFragmentManager)
        salonViewPagerAdapter.addFragment(ServiceFragment(), "Услуги")
        salonViewPagerAdapter.addFragment(MasterFragment(), "Мастеры")
        binding.viewPager.adapter = salonViewPagerAdapter
        binding.toolbar.setupWithViewPager(binding.viewPager)
        binding.viewPager.isVisible = true
        binding.shimmer.stopShimmer()
        binding.shimmer.isVisible = false
    }

    override fun onCreateOptionsMenu(menu: Menu, inflater: MenuInflater) {
        inflater.inflate(R.menu.feedback_menu, menu)
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        return return when (item.itemId) {
            R.id.feedback -> {
                val bottomSheet = FeedbackBottomSheet()
                bottomSheet.arguments = bundleOf(FeedbackBottomSheet.TITLE to title)
                bottomSheet.show(childFragmentManager, FeedbackBottomSheet.TAG)
                true
            }
            else -> {
                super.onOptionsItemSelected(item)
            }
        }
    }


}