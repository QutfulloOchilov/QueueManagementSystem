package tj.behruz.queuemanagement.presentation.ui

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import tj.behruz.queuemanagement.R
import tj.behruz.queuemanagement.databinding.SignInFragmentBinding
import tj.behruz.queuemanagement.presentation.extension.navigateToScreen

class SignInFragment : Fragment() {

    private lateinit var _binding: SignInFragmentBinding
    private val binding get() = _binding

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = SignInFragmentBinding.inflate(layoutInflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        binding.signUp.setOnClickListener {
            navigateToScreen(R.id.action_nav_sign_in_to_signUpFragment)
        }
        binding.button.setOnClickListener {
            navigateToScreen(R.id.action_nav_sign_in_to_nav_home)
        }
    }


}