import easygui
import pickle
import numpy as np
import matplotlib.pyplot as plt
from scipy.fft import fft, fftfreq
import os

import pickle

# open a file, where you stored the pickled data
file = open('./data/program_data.dat', 'rb')

# dump information to that file
data = pickle.load(file)


print(data[0])

# Number of sample points
N = len(data[0])
# sample spacing
T = 1.0 / 800.0
x = np.linspace(0.0, N*T, N, endpoint=False)

yf = fft(data[0])
xf = fftfreq(N, T)[:N//2]

plt.plot(xf, 2.0/N * np.abs(yf[0:N//2]))
plt.grid()
plt.show()